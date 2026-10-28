import difflib

for name in ['Frm_Vouchers.cs', 'Frm_Vouchers_multi.cs', 'Frm_generatefee.cs', 'frmUnpostVoucher.cs']:
    try:
        with open(rf'@forms\{name}', 'r', encoding='utf-8') as f1, open(rf'scratch\backup_fee_cs\{name}.bak', 'r', encoding='utf-8') as f2:
            lines1 = f1.readlines()
            lines2 = f2.readlines()
        diff = list(difflib.unified_diff(lines2, lines1, fromfile=f'{name}.bak', tofile=name))
        if diff:
            print(f"=== DIFF IN {name} ===")
            for line in diff:
                print(line, end='')
    except Exception as e:
        print(f"Error {name}: {e}")
