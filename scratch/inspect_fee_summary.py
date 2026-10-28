import re

with open('DataSet_Fee_Summary_Reports.xsd', 'r', encoding='utf-8') as f:
    xsd = f.read()

matches = re.findall(r'<DbSource[\s\S]*?</DbSource>', xsd)
print(f"Found {len(matches)} DbSource in DataSet_Fee_Summary_Reports.xsd")

for i, m in enumerate(matches):
    cmd = re.findall(r'<CommandText>([\s\S]*?)</CommandText>', m)
    name = re.findall(r'Name="([^"]*)"', m)
    table = re.findall(r'Table="([^"]*)"', m)
    print(f"\n--- Method {i+1}: Table={table} Name={name} ---")
    if cmd:
        print("CommandText:")
        print(" ".join(cmd[0].split())[:400])
