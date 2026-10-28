with open(r'@forms\Frm_generatefee_multi.Designer.cs', 'r') as f:
    for idx, line in enumerate(f, 1):
        if 'btnproc' in line or 'button3' in line:
            print(f"Designer L{idx}: {line.strip()}")

with open(r'@forms\Frm_generatefee_multi.cs', 'r') as f:
    for idx, line in enumerate(f, 1):
        if 'btnproc' in line or 'button3' in line:
            print(f"CS L{idx}: {line.strip()}")
