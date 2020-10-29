#!/bin/bash
ls *.tap -1 > tap.list
i=1 #counter
while IFS= read -r tap_file
do
	Tapatap -o file$i.bin < $tap_file
	let i++
done < tap.list

for((j=1;j<i;j++));do
	./file$i.bin &
done < tap.list