if __name__ == '__main__':
    n = int(input())
    numbers =[]
    for i in range(n):
        numbers.append(i)
    result_numbers = [x*x for x in numbers]
    for i in result_numbers:
        print(i)