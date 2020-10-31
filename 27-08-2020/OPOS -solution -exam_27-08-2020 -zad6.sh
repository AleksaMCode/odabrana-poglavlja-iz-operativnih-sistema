#!/bin/bash
ls *.tap -1 > tap.list
i=1 #counter
while IFS= read -r tap_file
do
	Tapatap -i $tap_file 1>file$i.bin 2>&1
	chmod +x file$i.bin
	./file$i.bin > file$i.log
	let i++
done < tap.list