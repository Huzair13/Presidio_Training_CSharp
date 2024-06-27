def printStarPyramid(rows):
    for i in range(rows):
        print(' ' * (rows - i - 1), end='')
        print('*' * (2 * i + 1))

num_rows = int(input("Enter the Number of Rows : "))
printStarPyramid(num_rows)
