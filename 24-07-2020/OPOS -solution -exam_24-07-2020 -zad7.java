public class Main {
    public static void main(String[] args) throws Exception {
        List<Task> tasks = new List<Task>();

        //Rezultati funkcija
        Dictionary<int, int> resF1 = new Dictionary<int, int>();
        Dictionary<int, int> resF2 = new Dictionary<int, int>();

        //Jasno je na osnovu teksta zadatka da se F1 mora izvrsiti za vrijednosti[1, 105] u sklopu poziva F2
        for (int i = 1; i <= 105; ++i) {
            if (tasks.Size() < 3) { //FaaS klaster omogucuje konkurentno izvrsavanje max. 3 funkcije
                try {
                    tasks.Add(ScheduleAsync(F1, i));
                } catch (Exception e) {
                    System.out.println("F1 - value " + i + "-> cluster busy");
                }
            } else {
                for (Task task : tasks) {
                    resF1.Add(i, Wait(task));
                }
                tasks.Clear();
            }

            //F2 izracunavanje na osnovu F1
            if ((i >= 80 && i <= 105) && tasks.Size() < 3) {
                try {
                    tasks.Add(ScheduleAsync(F2, resF1[i]));
                } catch (Exception e) {
                    System.out.println("F1 - value " + i + "-> cluster busy");
                }
            } else {
                for (Task task : tasks) {
                    resF2.Add(i, Wait(task));
                }
                tasks.Clear();
            }
        }
    }
}