#!/bin/bash

DESC_FILE=../data_proto/msg_desc.bin

./pb-cpp/protoc --version

cd pb_proto
desc_proto=' '
list=${desc_proto}

for file in `ls | grep .proto$`
do
	if [ -f ${file} ] 
	then
		list=${list}' '${file}
	fi
done


echo '======== Build Messages between Server and Client:'
echo '<<<------'${list}' ------>>>'
../pb_cpp/protoc.exe -I=.  ${list} --java_out=..

echo 'Press enter key to exit'
read n