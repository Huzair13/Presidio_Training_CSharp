if __name__ == '__main__':
    n = int(input())
    arr = map(int, input().split())
    arr_set = set(arr)
    sorted_arr = sorted(list(arr_set),reverse=True)
        
    print(sorted_arr[1])