# 6. zadatak
$ ls a*a.txt | >&2 | sort -r | cat

# 7. zadatak
# U komandnoj liniji uradimo sljedece:
touch script.sh && chmod 777 script.sh
# Unutar script.sh pišemo
#!/bin/bash
echo -e "Choose operation:\n1 - addition\n2 - subtraction\n3 - multiplication\n4 - division"
read ch
res=0
if [[ $ch -eq 1 ]]
then
	res=`echo $1 + $2 | bc`
elif [[ $ch -eq 2 ]]
then
	res=`echo $1 - $2 | bc`
elif [[ $ch -eq 3 ]]
then
	res=`echo $1 \* $2 | bc`
elif [[ $ch -eq 4 ]]
then
	res=`echo "scale=2; $1 / $2" | bc`
else
	echo "Error" && exit 1
fi
echo "Result: $res"

# Pokretanje skripte:
$ ./script.sh 5 6.2