# Enter your code here. Read input from STDIN. Print output to STDOUT
from collections import Counter
number_of_shoes = int(input())
shoes = list(map(int,(input().split())))
number_of_customers = int(input())
purchase = []
shoes_count = Counter(shoes)
for i in range(0,number_of_customers):
    x,y = map(int,input().split())
    lst = [x,y]
    purchase.append(lst)

amount_earned = 0
for i in purchase:
    if(shoes_count[i[0]]>0):
        amount_earned += i[1]
        shoes_count[i[0]]-=1
print(amount_earned)