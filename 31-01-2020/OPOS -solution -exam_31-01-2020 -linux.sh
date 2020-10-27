#6. zadatak
$ find . -maxdepth 1 -type f | grep "a*a.txt" | 1>&2 | sort -r | cat
#2. nacin
$ ls a*a.txt -1 1>&2 | sort -r | cat 

#7. zadatak - zadatak uradjen sa tri argumenta, pogledati "OPOS -solution -exam_11-09-2020 -linux.sh" za rjesenje sa 2 argumenta
#checkString.sh:
#!/bin/bash
if [ "$(echo $1 | grep -E "[0-9]+")" != '' ]
then
    exit 0
else
    exit 1
fi

#script.sh:
#!/bin/bash
bash checkString.sh "$1"
if [ $? -eq 1 ]; then echo "1. arg. is not a number : $1" && exit 1; fi
bash checkString.sh "$2"
if [ $? -eq 1 ]; then echo "2. arg. is not a number : $2" && exit 1; fi

if [ "$3" == "+" ]
then
    echo "$(( $1 + $2 ))"
elif [ "$3" == "-" ]
then
    echo "$(( $1 - $2 ))"
elif [ "$3" == "/" ]
then
    echo "scale=2 ; $1 / $2" | bc # ako treba tacno dijeljenje
    #echo "$(( $1 / $2 ))"
elif [ "$3" == "*" ]
then
    echo "$(( $1 * $2 ))"
else
    echo "$3 is not a valid operation."
fi