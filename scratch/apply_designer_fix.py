with open('Report_DataSet_new.Designer.cs', 'r', encoding='utf-8') as f:
    cs = f.read()

# A. FEE_HISTORY:
t1 = "class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id"
r1 = "class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id"
c1 = cs.count(t1)
print(f"CS FEE_HISTORY count: {c1}")
assert c1 == 8, f"Expected 8 matches, got {c1}"
cs = cs.replace(t1, r1)

# B. DEFAULTER_DETAIL
t2 = """FROM            FEE_MASTER INNER JOIN
                         student ON FEE_MASTER.s_id = student.s_id INNER JOIN
                         Sections ON student.SECTION_ID = Sections.SECTION_ID INNER JOIN
                         class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id"""
r2 = """FROM            FEE_MASTER INNER JOIN
                         student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
                         Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
                         class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id"""
c2 = cs.count(t2)
if c2 == 0:
    t2 = t2.replace('\n', '\r\n')
    r2 = r2.replace('\n', '\r\n')
    c2 = cs.count(t2)
print(f"CS DEFAULTER_DETAIL count: {c2}")
assert c2 == 2, f"Expected 2 matches, got {c2}"
cs = cs.replace(t2, r2)

# C. DateWisePostedReport
t3 = """FROM            FEE_MASTER INNER JOIN
                         student ON FEE_MASTER.s_id = student.s_id INNER JOIN
                         Sections ON student.SECTION_ID = Sections.SECTION_ID INNER JOIN
                         class ON student.c_id = class.c_id"""
r3 = """FROM            FEE_MASTER INNER JOIN
                         student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
                         Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
                         class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id"""
c3 = cs.count(t3)
if c3 == 0:
    t3 = t3.replace('\n', '\r\n')
    r3 = r3.replace('\n', '\r\n')
    c3 = cs.count(t3)
print(f"CS DateWisePostedReport count: {c3}")
assert c3 == 1, f"Expected 1 match, got {c3}"
cs = cs.replace(t3, r3)

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
c4a = cs.count(t4a)
if c4a == 0:
    t4a = t4a.replace('\n', '\r\n')
    r4a = r4a.replace('\n', '\r\n')
    c4a = cs.count(t4a)
print(f"CS MonthlyFee Cmd0 count: {c4a}")
assert c4a == 1, f"Expected 1 match, got {c4a}"
cs = cs.replace(t4a, r4a)

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
c4b = cs.count(t4b)
if c4b == 0:
    t4b = t4b.replace('\n', '\r\n')
    r4b = r4b.replace('\n', '\r\n')
    c4b = cs.count(t4b)
print(f"CS MonthlyFee Cmd1 count: {c4b}")
assert c4b == 1, f"Expected 1 match, got {c4b}"
cs = cs.replace(t4b, r4b)

# E. UnpaidVouchers
t5 = "FEE_DETAIL ON FEE_MASTER.FEE_MASTER_ID = FEE_DETAIL.FEE_MASTER_ID AND FEE_MASTER.branch_id = FEE_DETAIL.branch_id INNER JOIN"
r5 = "FEE_DETAIL ON FEE_MASTER.FEE_MASTER_ID = FEE_DETAIL.FEE_MASTER_ID AND FEE_MASTER.branch_id = FEE_DETAIL.branch_id AND FEE_MASTER.SessionID = FEE_DETAIL.SessionID INNER JOIN"
c5 = cs.count(t5)
print(f"CS UnpaidVouchers count: {c5}")
assert c5 == 1, f"Expected 1 match, got {c5}"
cs = cs.replace(t5, r5)

# F. BankwisePostedReport
t6 = "FEE_DETAIL.SessionID = FEE_MASTER.SessionID"
r6 = "FEE_DETAIL.SessionID = FEE_MASTER.SessionID AND FEE_DETAIL.branch_id = FEE_MASTER.branch_id"
target_bank = "FEE_DETAIL.FEE_MASTER_ID = FEE_MASTER.FEE_MASTER_ID AND FEE_DETAIL.SessionID = FEE_MASTER.SessionID\r\n"
repl_bank = "FEE_DETAIL.FEE_MASTER_ID = FEE_MASTER.FEE_MASTER_ID AND FEE_DETAIL.SessionID = FEE_MASTER.SessionID AND FEE_DETAIL.branch_id = FEE_MASTER.branch_id\r\n"
if target_bank in cs:
    cs = cs.replace(target_bank, repl_bank)
    print("Replaced CS target_bank crlf")
elif target_bank.replace('\r\n', '\n') in cs:
    cs = cs.replace(target_bank.replace('\r\n', '\n'), repl_bank.replace('\r\n', '\n'))
    print("Replaced CS target_bank lf")

with open('Report_DataSet_new.Designer.cs', 'w', encoding='utf-8') as f:
    f.write(cs)
print("Report_DataSet_new.Designer.cs updated successfully!")
