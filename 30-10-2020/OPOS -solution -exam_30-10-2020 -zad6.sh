#!/bin/bash
ls *.tap -1 > kripl.list
i=1
for kripl_file in $(ls *.krrr)
do
	$kripl_file > KriplKripl 2> file$i.bin
	chmod +x file$i.bin
	./file$i.bin > file$i.log
	let i++
done