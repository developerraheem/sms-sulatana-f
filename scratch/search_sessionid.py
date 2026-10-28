import os

for root, dirs, files in os.walk('.'):
    if '.git' in root or 'bin' in root or 'obj' in root or 'scratch' in root or '.system_generated' in root:
        continue
    for f in files:
        if f.endswith('.cs'):
            p = os.path.join(root, f)
            with open(p, 'r', encoding='utf-8', errors='ignore') as file:
                for idx, line in enumerate(file, 1):
                    if 'sessionid' in line.lower() and '=' in line and not '==' in line and not '!=' in line:
                        print(f"{p}:{idx}: {line.strip()}")
