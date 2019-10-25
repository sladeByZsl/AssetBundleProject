#!/bin/bash

rm -f ./pb_cs/*


cd pb_proto

DESC_FILE=../../data_proto/msg_desc.bin


clientFilePath='../../data_proto/xml_proto'
clientfile='level_setting.proto level_list.proto match3_common.proto hero.proto match3_tutorials.proto enum_define.proto'

csfile=`find . -maxdepth 1 -name '*.proto'`


for file in $clientfile
do
	cpfile=$clientFilePath'/'$file
	if [ -f $cpfile ]
	then
		\cp $cpfile .
	fi
done
cp -r ../proto_include/google .
rm -f ../pb_cs/*
for file in $csfile
do
	if [ -f $file ] 
	then
		../pb_net/protogen.exe -i:${file}  -o:../pb_cs/${file}.cs -ns:FunPlus.Common.Config
		echo ${file}
	fi
done


 \cp ../pb_cs/* ../../../Assets/client-code/MsgHandle/

list=`find .  -name '*.proto'`

echo $list

../pb_cpp/protoc.exe -I=. ${list} -I=../proto_include --descriptor_set_out=${DESC_FILE}


for file in $clientfile
do
	if [ -f $file ]
	then
		rm -f $file
	fi
done

rm -rf ./google

echo Please check the log above and press enter to exit!
read n