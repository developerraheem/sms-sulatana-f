import difflib

with open(r'@class\FEE.cs', 'r', encoding='utf-8') as f1, open(r'scratch\backup_fee_cs\FEE.cs.bak2', 'r', encoding='utf-8') as f2:
    lines1 = f1.readlines()
    lines2 = f2.readlines()

diff = list(difflib.unified_diff(lines2, lines1, fromfile='bak2', tofile='current'))
for line in diff:
    print(line, end='')
