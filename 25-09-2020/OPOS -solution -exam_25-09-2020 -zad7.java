public class Main {
    public static void main(String[] args) throws Exception {
        List<Task> tasks = new List<Task>();

        //Rezultati funkcija
        Dictionary<int, int> resF1 = new Dictionary<int, int>();
        Dictionary<int, int> resF2 = new Dictionary<int, int>();

        //Jasno je na osnovu teksta zadatka da se f1 izvrsava za vrijednosti[1, 1100] u sklopu poziva f2
        for (int i = 1; i <= 1100; ++i) {
            if (tasks.Size() < 2) { //FaaS klaster omogucuje konkurentno izvrsavanje max. 2 funkcije
                try {
                    tasks.Add(ScheduleAsync(f1(4), i)); // int f1(int) <- 4 sec.
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
            if (i >= 1080 && i <= 1105) {
                if (tasks.Size() < 2) {
                    try {
                        tasks.Add(ScheduleAsync(f2(8), resF1[i])); // int f2(int) <- 8 sec.
                    } catch (Exception e) {
                        System.out.println("F2 - value " + i + " -> cluster busy");
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
}