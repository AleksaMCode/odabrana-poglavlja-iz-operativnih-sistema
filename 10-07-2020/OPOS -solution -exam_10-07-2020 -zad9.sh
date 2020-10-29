#!/bin/bash
ssh root@241.22.12.1
scp root@241.22.12.1:/output/map_reduce/out1.chunk
hdfs dfs -mkdir /mydir
hdfs dfs -copyFromLocal /output/map_reduce/out1.chunk /mydir
chmod a+x runMapReduce.sh
./runMapReduce.sh mapper.py reducer.py
hdfs dfs -copyToLocal /mydir/out1.chunk /output/map_reduce 
# ili hdfs dfs -get /mydir/out1.chunk /output/map_reduce 