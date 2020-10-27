#6. zadatak
#Ovo radi pod uslovom da je TEST_VARIABLE kreirana na sljedeci nacin, npr:
$ export TEST_VARIABLE="This is a test" # mogli smo ovo staviti u samu skriptu

$ echo $'#!/bin/bash\necho $TEST_VARIABLE' > script.sh && chmod +x script.sh && ./script.sh
#ili
$ echo -e "#!/bin/bash\necho $TEST_VARIABLE" > script.sh && chmod +x script.sh && ./script.sh


#7. zadatak
$ find . -iname "*.txt" -type f -printf "%f\n" | sort -r | nl | cut -c5-
#Ako na sistemu nema komanda nl, onda mozemo uradite sljedece:
$ find . -iname "*.txt" -type f -printf "%f\n" | sort -r | awk '{print NR,$0}'

#8. zadatak
#!/bin/bash
current_dir=${PWD##*/}
i=1
if [[ "$current_dir" =~ "$1" ]]
then
	for file in $(ls)
	do
		mv $file "$i-$file" && i=$((i+1))
	done
else
	exit 1
fi

#9. zadatak
$ grep -oE "$(./generateRegex.bin)" test.txt | xargs echo #opcija -o ispisuje samo match grupe, flag -E tretira patern kao ERE (extended regular expression)

#10. zadatak
#!/bin/bash
i=1
while true
do
	if [[ "$(ls $1)" != "" ]] # ako treba rekurzivna pretraga: umjesto ls upotrijebiti find . -type f $1
	then
		ls -1 > list_$i.log
	fi
	rm list_$i.log 2>>error.log
	let i++
	sleep 5
done
