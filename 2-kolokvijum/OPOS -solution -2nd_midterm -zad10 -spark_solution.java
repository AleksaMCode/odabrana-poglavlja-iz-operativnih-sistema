import org.apache.spark.api.java.JavaSparkContext;
import org.apache.spark.SparkConf;
import org.apache.log4j.Level;
import org.apache.log4j.Logger;

import org.apache.spark.api.java.JavaPairRDD;
import org.apache.spark.api.java.JavaRDD;

import scala.Tuple2;

public class Main {

	public static void main(String[] args) {
		Logger.getLogger("org.apache").setLevel(Level.WARN);

		SparkConf conf = new SparkConf().setAppName("MyApp").setMaster("local[*]");
		JavaSparkContext sc = new JavaSparkContext(conf);

		JavaRDD<String> initialRdd = sc.textFile("src/main/resources/publication.txt");

		JavaPairRDD<Integer, String> pairRdd = initialRdd.mapToPair(value -> {
			String[] str = value.split(" ");
			return new Tuple2<>(Integer.parseInt(str[0]), str[1]);
		});

		System.out.println(pairRdd.filter(value -> value._1 > 2018 ? true : false)
				.filter(value -> value._2.startsWith("On") ? true : false)
				.map(value -> value._2)
				.reduce((x, y) -> x + ", " + y));

		sc.close();
	}
}