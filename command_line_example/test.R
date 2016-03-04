#!/usr/bin/env Rscript

#..thanks to http://www.r-bloggers.com/parse-arguments-of-an-r-script/
  
## Collect arguments
args <- commandArgs(TRUE)

input_file <- args[1]
work_function <- args[2]
output_file <- args[3]

input_df <- read.csv(input_file, as.is = TRUE)

if(work_function == 'mean'){ 
  fn <- mean 
} else if(work_function == 'median'){ 
  fn <- median 
} else  stop('This function only applies mean and median column transformations.')

cat(sprintf('Printing column %ss to file\n:', work_function))
(results <- as.data.frame(lapply(input_df, fn)))
write.csv(results, file = output_file, row.names = FALSE, quote = FALSE)
