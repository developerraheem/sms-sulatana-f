import re

with open('DataSet_Fee_Summary_Reports.xsd', 'r', encoding='utf-8') as f:
    xsd = f.read()

matches = re.findall(r'<DbSource[\s\S]*?</DbSource>', xsd)

for i in [9, 10, 11]:
    if i < len(matches):
        m = matches[i]
        cmd = re.findall(r'<CommandText>([\s\S]*?)</CommandText>', m)
        name = re.findall(r'Name="([^"]*)"', m)
        print(f"\n--- Method {i+1}: Name={name[:3]} ---")
        if cmd:
            print("CommandText:\n", cmd[0])
