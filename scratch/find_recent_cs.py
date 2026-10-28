import os, time

now = time.time()
recent_files = []
for root, dirs, files in os.walk('.'):
    if '.git' in root or 'bin' in root or 'obj' in root or 'scratch' in root or '.system_generated' in root:
        continue
    for f in files:
        if f.endswith('.cs'):
            p = os.path.join(root, f)
            mtime = os.path.getmtime(p)
            recent_files.append((mtime, p))

recent_files.sort(reverse=True)
for mtime, p in recent_files[:20]:
    print(f"{time.ctime(mtime)}: {p}")
