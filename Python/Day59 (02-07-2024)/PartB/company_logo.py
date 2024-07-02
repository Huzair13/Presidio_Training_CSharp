#!/bin/python3

import math
import os
import random
import re
import sys

from collections import Counter

if __name__ == '__main__':
    s = input()
    string_counter ={}
    for i in s:
        if i in string_counter:
            string_counter[i]+=1
        else:
            string_counter[i]=1
    sorted_string_count = dict(sorted(string_counter.items(),key =lambda item:(-item[1],item[0])))
    
    count = 0
    for key, value in sorted_string_count.items():
        if count < 3:
            print(key, value)
            count += 1
        else:
            break
    
