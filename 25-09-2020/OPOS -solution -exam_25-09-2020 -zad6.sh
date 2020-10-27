#!/bin/bash
ls *.gm -1 > gigamega.list
i=1 #counter
while IFS= read -r gm_file
do
	GigaMega -ulaz $gm_file > file$i.gm
	./file$i.gm 1>izlaz$i.log 2>&1
	let i++
done < gigamega.list