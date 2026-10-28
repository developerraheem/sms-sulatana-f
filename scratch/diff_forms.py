with open(r'@forms\Frm_generatefee_multi.cs', 'r', encoding='utf-8') as f1, open(r'scratch\backup_fee_cs\Frm_generatefee_multi.cs.bak', 'r', encoding='utf-8') as f2:
    lines1 = f1.readlines()
    lines2 = f2.readlines()

import difflib
diff = list(difflib.unified_diff(lines2, lines1, fromfile='bak', tofile='current'))
for line in diff[:50]:
    print(line, end='')
