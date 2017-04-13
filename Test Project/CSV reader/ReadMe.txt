The task description:

In the attached archive, there are two specialized types of CSV files – so-called "LP" and "TOU" files (see sample files folder). Write a console program that will:

1. Read CSV files;

2. For each file, calculate the average value using a) the "Data Value" column for the "LP" file type or b) or the "Energy" column for the "TOU" file type;

3. Find values that are 20% above or below the average

4. Print any abnormal values found to the console using the following format:

{file name} {datetime} {value} {median value}

·         Note: to get {datetime} use "Date/Time" column in csv file (for both file types).


Things to look out for & further questions:

1. Your program structure should ideally allow easy adding of new processors.

2. How can we process 10e6 files quickly?




Notes:

There is some code repetition in LPFileResult.cs and TOUFileResult.cs but the idea was that methods implementation would be defferent