#!/bin/bash
ls *.tap -1 > tap.list
i=1 #counter
while IFS= read -r tap_file
do
	Tapatap -i $tap_file 1>file$i.tap 2>&1
	./file$i.tap > file$i.log
	let i++
done < tap.list