#read files
file1 = open("files/test.txt")
content = file1.read()
print(content)

# write to files
file2 = open('files/file2.txt', 'w')

file2.write('Programming is Fun.\n')
file2.write('Huzair is a good boy\n')

#closing the files
file1.close()

#with open
with open("files/test.txt", "r") as file1:
    content = file1.read()
    print(content)


#writing to excel file
import xlwt 
from xlwt import Workbook 
wb = Workbook() 

sheet1 = wb.add_sheet('Sheet 1') 
  
sheet1.write(1, 0, 'ISBT DEHRADUN') 
sheet1.write(2, 0, 'SHASTRADHARA') 
sheet1.write(3, 0, 'CLEMEN TOWN') 
sheet1.write(4, 0, 'RAJPUR ROAD') 
sheet1.write(5, 0, 'CLOCK TOWER') 
sheet1.write(0, 1, 'ISBT DEHRADUN') 
sheet1.write(0, 2, 'SHASTRADHARA') 
sheet1.write(0, 3, 'CLEMEN TOWN') 
sheet1.write(0, 4, 'RAJPUR ROAD') 
sheet1.write(0, 5, 'CLOCK TOWER') 
  
wb.save('files/xlwt example.xls') 