with open('DataSet_Fee_Summary_Reports.xsd', 'r', encoding='utf-8') as f:
    text = f.read()

import re
matches = re.findall(r'<DbSource[\s\S]*?SUMMARY_BANKWISEPOSTED[\s\S]*?</DbSource>', text)
for m in matches:
    cmd = re.findall(r'<CommandText>([\s\S]*?)</CommandText>', m)
    for c in cmd:
        print("SUMMARY_BANKWISEPOSTED CommandText:\n", c)
