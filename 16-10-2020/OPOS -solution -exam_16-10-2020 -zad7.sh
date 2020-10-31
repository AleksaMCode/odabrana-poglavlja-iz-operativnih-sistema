#!/bin/bash
i=1
for gm_file in $(ls *.gm)
do
	$gm_file > GigaMega 2> $gm_file.bin
	chmod +x $gm_file.bin
	GigaMega -num $i 1>izlaz$i.log 2>&1
	let i++
done