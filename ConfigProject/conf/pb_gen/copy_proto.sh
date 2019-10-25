#!/bin/bash

xml_path=../data_proto/xml_proto
xml_sheet_path=../data_proto/xml_sheet_proto

cp pb_proto/match3_*.proto ${xml_path}
cp pb_proto/level_*.proto ${xml_path}
cp pb_proto/hero*.proto ${xml_path}
cp pb_proto/i*.proto ${xml_path}