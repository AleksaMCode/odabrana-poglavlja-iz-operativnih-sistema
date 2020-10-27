import java.io.IOException;
import java.util.*;

import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapred.*;

public class TaskSevenReducer extends MapReduceBase implements Reducer<Text, LongWritable, Text, LongWritable> {
	
	public void reduce(Text t_key, Iterator<LongWritable> values, OutputCollector<Text,LongWritable> output, Reporter reporter) throws IOException {
		// reducing steps ...
	}
}