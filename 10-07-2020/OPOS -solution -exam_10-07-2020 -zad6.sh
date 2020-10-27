#!/bin/bash
ls *.tap -1 > tap.list
i=1 #counter
while IFS= read -r tap_file
do
	$tap_file > Tapatap -o file$i.tap
	let i++
done < tap.list

for((j=1;j<i;j++));do
	./file$i.tap &
done < tap.list