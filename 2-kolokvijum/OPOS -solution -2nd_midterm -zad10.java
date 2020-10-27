import java.io.IOException;
import java.util.*;

import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapred.*;

public class SalesCountryReducer extends MapReduceBase implements Reducer<IntWritable, Text, IntWritable, Text> {

    public void reduce(IntWritable key, Text value, OutputCollector<IntWritable, Text> output, Reporter reporter) {
        if (key.get() > 2018 && value.toString().startsWith("On")) {
            output.collect(key,value);
        }
    }
}