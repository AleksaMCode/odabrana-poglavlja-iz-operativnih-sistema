public class Main {
    public static void main(String[] args){
        List<Task> tasks = new List<Task>();

        //Rezultati funkcija
        Dictionary<int, int> resF1 = new Dictionary<int, int>();
        Dictionary<int, int> resF2 = new Dictionary<int, int>();

        //Jasno je na osnovu teksta zadatka da se F1 mora izvrsiti za vrijednosti[1, 105] u sklopu poziva F2
        for (int i = 1; i <= 1084; ++i) {
            if (tasks.Size() < 4) { //FaaS klaster omogucuje konkurentno izvrsavanje max. 4 funkcije
                tasks.Add(ScheduleAsync(F1, i));
            } else {
                for (Task task : tasks) {
                    resF1.Add(i, Wait(task));
                }
                tasks.Clear();
            }

            //F2 izracunavanje na osnovu F1
            if (i >= 80 && i <= 105) {
                if (tasks.Size() < 4) {
                    tasks.Add(ScheduleAsync(F2, resF1[i]));
                } else {
                    for (Task task : tasks) {
                        resF2.Add(i, Wait(task));
                    }
                    tasks.Clear();
                }
            }
        }
    }
}