import java.io.IOException;
import java.util.*;

import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapred.*;

public class SalesCountryReducer extends MapReduceBase implements Reducer<IntWritable, Text, IntWritable, Text,> {

    public void reduce(IntWritable t_key, Iterator<Text> values, OutputCollector<IntWritable, Text> output, Reporter reporter) {
		IntWritable key = t_key;
		while(values.hasNext()) {
			Text publication = (Text) values.next();
			if (key.get() > 2018 && publication.toString().startsWith("On")) {
				output.collect(t_key,value);
			}
		}
    }
}