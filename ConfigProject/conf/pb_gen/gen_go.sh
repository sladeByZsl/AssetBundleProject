#!/bin/bash

rm -rf tmp
mkdir tmp

cp pb_proto/*.proto tmp

clientFilePath='../data_proto/xml_proto'
clientfile='level_setting.proto level_list.proto match3_common.proto hero.proto match3_tutorials.proto enum_define.proto'

csfile=`find . -maxdepth 1 -name '*.proto'`


for file in $clientfile
do
	cpfile=$clientFilePath'/'$file
	if [ -f $cpfile ]
	then
		\cp $cpfile tmp
	fi
done

cd tmp

for file in `ls *.proto`
do
	sed -i '' '/^option /d'  $file;
	sed -i '' '2 a\
option go_package = "matchproto";
' $file;
done


list=`find . -name '*.proto'`

../bin/protoc --plugin=protoc-gen-go=../bin/protoc-gen-go -I=../proto_include --go_out=../pb_go -I=.  ${list}

cd ..

rm -rf tmp

echo Please check the log above and press enter to exit!
read n
