with open('Report_DataSet_new.xsd', 'r', encoding='utf-8') as f:
    text = f.read()

import re
matches = re.findall(r'<DbSource[\s\S]*?FillByMonth[\s\S]*?</DbSource>', text)
for m in matches:
    cmd = re.findall(r'<CommandText>([\s\S]*?)</CommandText>', m)
    for c in cmd:
        print("FillByMonth CommandText:\n", c)
