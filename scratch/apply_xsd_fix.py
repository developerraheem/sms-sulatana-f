def update_files():
    # 1. Update Report_DataSet_new.xsd
    with open('Report_DataSet_new.xsd', 'r', encoding='utf-8') as f:
        xsd = f.read()

    # A. FEE_HISTORY: remove student.c_id = class.c_id
    t1 = "class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id"
    r1 = "class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id"
    print(f"XSD FEE_HISTORY count: {xsd.count(t1)}")
    xsd = xsd.replace(t1, r1)

    # B. DEFAULTER_DETAIL
    t2 = """FROM            FEE_MASTER INNER JOIN
                         student ON FEE_MASTER.s_id = student.s_id INNER JOIN
                         Sections ON student.SECTION_ID = Sections.SECTION_ID INNER JOIN
                         class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id"""
    r2 = """FROM            FEE_MASTER INNER JOIN
                         student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
                         Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
                         class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id"""
    # handle newline variations
    if t2 in xsd:
        print("Found t2 with lf")
        xsd = xsd.replace(t2, r2)
    elif t2.replace('\n', '\r\n') in xsd:
        print("Found t2 with crlf")
        xsd = xsd.replace(t2.replace('\n', '\r\n'), r2.replace('\n', '\r\n'))
    else:
        print("WARNING: t2 not found in xsd!")

    # C. DateWisePostedReport
    t3 = """FROM            FEE_MASTER INNER JOIN
                         student ON FEE_MASTER.s_id = student.s_id INNER JOIN
                         Sections ON student.SECTION_ID = Sections.SECTION_ID INNER JOIN
                         class ON student.c_id = class.c_id"""
    r3 = """FROM            FEE_MASTER INNER JOIN
                         student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
                         Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
                         class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id"""
    if t3 in xsd:
        print("Found t3 with lf")
        xsd = xsd.replace(t3, r3)
    elif t3.replace('\n', '\r\n') in xsd:
        print("Found t3 with crlf")
        xsd = xsd.replace(t3.replace('\n', '\r\n'), r3.replace('\n', '\r\n'))
    else:
        print("WARNING: t3 not found in xsd!")

    # D. MonthlyFee Command 0
    t4a = """FROM            FEE_DETAIL AS A INNER JOIN
                         FEE_MASTER AS B ON A.FEE_MASTER_ID = B.FEE_MASTER_ID INNER JOIN
                         Fee_Head ON A.Fee_head_id = Fee_Head.Fee_head_id INNER JOIN
                         student ON B.s_id = student.s_id INNER JOIN
                         class ON student.c_id = class.c_id"""
    r4a = """FROM            FEE_DETAIL AS A INNER JOIN
                         FEE_MASTER AS B ON A.FEE_MASTER_ID = B.FEE_MASTER_ID AND A.branch_id = B.branch_id AND A.SessionID = B.SessionID INNER JOIN
                         Fee_Head ON A.Fee_head_id = Fee_Head.Fee_head_id AND A.branch_id = Fee_Head.branch_id INNER JOIN
                         student ON B.s_id = student.s_id AND B.branch_id = student.branch_id INNER JOIN
                         class ON B.C_ID = class.c_id AND B.branch_id = class.branch_id"""
    if t4a in xsd:
        print("Found t4a with lf")
        xsd = xsd.replace(t4a, r4a)
    elif t4a.replace('\n', '\r\n') in xsd:
        print("Found t4a with crlf")
        xsd = xsd.replace(t4a.replace('\n', '\r\n'), r4a.replace('\n', '\r\n'))
    else:
        print("WARNING: t4a not found in xsd!")

    # D. MonthlyFee Command 1 (FillByMonth)
    t4b = """FROM            FEE_DETAIL AS A INNER JOIN
                         FEE_MASTER AS B ON A.FEE_MASTER_ID = B.FEE_MASTER_ID INNER JOIN
                         Fee_Head ON A.Fee_head_id = Fee_Head.Fee_head_id INNER JOIN
                         student ON B.S_ID = student.s_id AND B.C_ID = student.c_id INNER JOIN
                         class ON student.c_id = class.c_id"""
    r4b = """FROM            FEE_DETAIL AS A INNER JOIN
                         FEE_MASTER AS B ON A.FEE_MASTER_ID = B.FEE_MASTER_ID AND A.branch_id = B.branch_id AND A.SessionID = B.SessionID INNER JOIN
                         Fee_Head ON A.Fee_head_id = Fee_Head.Fee_head_id AND A.branch_id = Fee_Head.branch_id INNER JOIN
                         student ON B.S_ID = student.s_id AND B.branch_id = student.branch_id INNER JOIN
                         class ON B.C_ID = class.c_id AND B.branch_id = class.branch_id"""
    if t4b in xsd:
        print("Found t4b with lf")
        xsd = xsd.replace(t4b, r4b)
    elif t4b.replace('\n', '\r\n') in xsd:
        print("Found t4b with crlf")
        xsd = xsd.replace(t4b.replace('\n', '\r\n'), r4b.replace('\n', '\r\n'))
    else:
        print("WARNING: t4b not found in xsd!")

    # E. UnpaidVouchers
    t5 = "FEE_DETAIL ON FEE_MASTER.FEE_MASTER_ID = FEE_DETAIL.FEE_MASTER_ID AND FEE_MASTER.branch_id = FEE_DETAIL.branch_id INNER JOIN"
    r5 = "FEE_DETAIL ON FEE_MASTER.FEE_MASTER_ID = FEE_DETAIL.FEE_MASTER_ID AND FEE_MASTER.branch_id = FEE_DETAIL.branch_id AND FEE_MASTER.SessionID = FEE_DETAIL.SessionID INNER JOIN"
    print(f"XSD UnpaidVouchers count: {xsd.count(t5)}")
    xsd = xsd.replace(t5, r5)

    # F. BankwisePostedReport
    t6 = "FEE_DETAIL.SessionID = FEE_MASTER.SessionID"
    r6 = "FEE_DETAIL.SessionID = FEE_MASTER.SessionID AND FEE_DETAIL.branch_id = FEE_MASTER.branch_id"
    # only replace where it's BANKWISEPOSTED
    target_bank = "FEE_DETAIL.FEE_MASTER_ID = FEE_MASTER.FEE_MASTER_ID AND FEE_DETAIL.SessionID = FEE_MASTER.SessionID\r\n"
    repl_bank = "FEE_DETAIL.FEE_MASTER_ID = FEE_MASTER.FEE_MASTER_ID AND FEE_DETAIL.SessionID = FEE_MASTER.SessionID AND FEE_DETAIL.branch_id = FEE_MASTER.branch_id\r\n"
    if target_bank in xsd:
        xsd = xsd.replace(target_bank, repl_bank)
        print("Replaced target_bank crlf")
    elif target_bank.replace('\r\n', '\n') in xsd:
        xsd = xsd.replace(target_bank.replace('\r\n', '\n'), repl_bank.replace('\r\n', '\n'))
        print("Replaced target_bank lf")

    with open('Report_DataSet_new.xsd', 'w', encoding='utf-8') as f:
        f.write(xsd)
    print("Report_DataSet_new.xsd written.")

update_files()
