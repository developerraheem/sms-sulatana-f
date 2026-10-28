with open(r'@forms\Frm_generatefee_multi.Designer.cs', 'r') as f:
    for idx, line in enumerate(f, 1):
        if 'comboBox1' in line:
            print(f"L{idx}: {line.strip()}")
