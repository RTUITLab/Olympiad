$stack = odcs config
$stack = $stack -replace '\d+\.\d+$', '''$0'''
$stack > .\stack.yml