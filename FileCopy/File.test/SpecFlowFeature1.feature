Feature: Copy File Operation

@mytag
Scenario: Single File Copy	
	Given "C:\\Test\\test.txt" file	
	When I copy in to "C:\\Destination" folder	
	Then the file "test.txt" is copied in "C:\\Destination" folder

@mytag
Scenario: Single File Copy	from a disk to another
	Given "C:\\Test\\test.txt" file	
	When I copy in to "D:\\Destination" folder	
	Then the file "test.txt" is copied in "D:\\Destination" folder

@mytag
Scenario: Copy All File From A Dirctory
	Given "C:\Test\New" the source folder	
	When I copy all the file in to "D:\\Destination" folder	
	Then the files "test.txt" and "aaa.txt" are copied in "D:\\Destination" folder
	
