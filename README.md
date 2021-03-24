# ShortestPath
This program computes the shortest path between two employees in a company organisation chart. 

Overview:

The program initializes the organisation structure from the file. 
The input file should be in the below format.

![image](https://user-images.githubusercontent.com/12036451/112260912-ce166a00-8ca5-11eb-941c-a3498c58ebca.png)

The first line is the header of the file containing column names Employee ID and name. 
Then subsequent line represents the employee ID and their name, delimited by pipe(|) symbol.

The keyword "RELATIONS" is used to separate the relationship inputs in the file and is case sensitive. 

The relations of the employee are keyed in one after the other using Employee ID with comma separator.

For example:  1, 2, 3 means that 1 is manager and their reportees are 2 and 3.

Assumptions:

1. Employee has only one reporting manager.
2. Employee ID is a positive integer and unique across employees in an organisation.
3. Employee ID starts from 1 to n where n is the total count of employees.
4. Employee name may not be unique and comparison is based on Employee ID only.
5. The input file format is valid and the structure is as described in overview section.

Program Dependency:

This application was developed using Visual Studio Professional 2019. The main solution is present in "ShortestPath.sln" file. 
It has 2 projects - ShortestPath console application and ShortestPathTests test application. Both the projects uses .Net Framework 4.8.

Steps to Execute the program:

1. Open the Solutions file - "ShortestPath.sln". It contains console application and the test project.

Run the test project:

1. Place the file -"Employees.txt" under ShortestPath/ShortestPathTests/InputFiles
2. Run all Tests. 
The test results will be as shown below.
![image](https://user-images.githubusercontent.com/12036451/112261834-87297400-8ca7-11eb-846e-0a912b387460.png)

Run the console application:

1. Place the file -"Employees.txt" under ShortestPath/ShortestPath/InputFiles
2. Run the console application.
The output will be printed on your console.
