public class Main {
    public static void main(String[] args){
        List<Task> tasks = new List<Task>();

        //Rezultati funkcija
        Dictionary<int, int> resF1 = new Dictionary<int, int>();
        Dictionary<int, int> resF2 = new Dictionary<int, int>();

        //Jasno je na osnovu teksta zadatka da se f1 mora izvrsiti za vrijednosti[1, 1084] u sklopu poziva f2
        for (int i = 1; i <= 1084; ++i) {
            if (tasks.Size() < 2) { //FaaS klaster omogucuje konkurentno izvrsavanje max. 2 funkcije
                tasks.Add(ScheduleAsync(f1(4), i)); // int f1(int) <- 4 sec.
            } else {
                for (Task task : tasks) {
                    resF1.Add(i, Wait(task));
                }
                tasks.Clear();
            }

            //f2 izracunavanje na osnovu f1
            if (i >= 1080 && i <= 1084) {
                if (tasks.Size() < 2) {
                    tasks.Add(ScheduleAsync(f2(10), resF1[i])); // int f2(int) <- 10 sec.
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