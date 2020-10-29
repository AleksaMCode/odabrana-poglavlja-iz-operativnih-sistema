public class Main {
    public static void main(String[] args) throws Exception {
        List<Task> tasks = new List<Task>();

        //Rezultati funkcija - da ne bi dolazilo do duplih poziva F2 i F3 cuvamo rezulate u Dictionary
        Dictionary<int, int> resF1 = new Dictionary<int, int>();
        Dictionary<int, int> resF2 = new Dictionary<int, int>();
        Dictionary<int, int> resF3 = new Dictionary<int, int>();
        //Jasno je na osnovu teksta zadatka da se F1 mora izvrsiti za vrijednosti[1, 200] u sklopu poziva F2 i F3
        for (int i = 1; i <= 200; ++i) {
            if (tasks.Size() < 4) { //FaaS klaster omogucuje konkurentno izvrsavanje max. 4 funkcije
                try {
                    tasks.Add(ScheduleAsync(F1, i));
                } catch (Exception e) {
                    System.out.println("F1 - value " + i + " -> cluster busy");
                }
            } else {
                for (Task task : tasks) {
                    resF1.Add(i, Wait(task));
                }
                tasks.Clear();
            }

            //F2 izracunavanje na osnovu F1
            if (tasks.Size() < 4) {
                try {
                    tasks.Add(ScheduleAsync(F2, resF1[i]));
                } catch (Exception e) {
                    System.out.println("F2 - value " + i + " -> cluster busy");
                }
            } else {
                for (Task task : tasks) {
                    resF2.Add(i, Wait(task));
                }
                tasks.Clear();
            }

            //F3 izracunavanje na osnovu F2
            if (tasks.Size() < 4) {
                try {
                    tasks.Add(ScheduleAsync(F3, resF3[i]));
                } catch (Exception e) {
                    System.out.println("F3 - value " + i + " -> cluster busy");
                }
            } else {
                for (Task task : tasks) {
                    resF3.Add(i, Wait(task));
                }
                tasks.Clear();
            }
        }
    }
}