with open('DataSet_Fee_Summary_Reports.xsd', 'r', encoding='utf-8') as f:
    xsd = f.read()

t = "FEE_DETAIL.FEE_MASTER_ID = FEE_MASTER.FEE_MASTER_ID AND FEE_DETAIL.SessionID = FEE_MASTER.SessionID"
r = "FEE_DETAIL.FEE_MASTER_ID = FEE_MASTER.FEE_MASTER_ID AND FEE_DETAIL.SessionID = FEE_MASTER.SessionID AND FEE_DETAIL.branch_id = FEE_MASTER.branch_id"

c = xsd.count(t)
print(f"Match count in DataSet_Fee_Summary_Reports.xsd: {c}")
assert c >= 2, f"Expected at least 2 matches, got {c}"
xsd = xsd.replace(t, r)

with open('DataSet_Fee_Summary_Reports.xsd', 'w', encoding='utf-8') as f:
    f.write(xsd)
print("Updated DataSet_Fee_Summary_Reports.xsd")

with open('DataSet_Fee_Summary_Reports.Designer.cs', 'r', encoding='utf-8') as f:
    cs = f.read()

c_cs = cs.count(t)
print(f"Match count in DataSet_Fee_Summary_Reports.Designer.cs: {c_cs}")
assert c_cs >= 2, f"Expected at least 2 matches, got {c_cs}"
cs = cs.replace(t, r)

with open('DataSet_Fee_Summary_Reports.Designer.cs', 'w', encoding='utf-8') as f:
    f.write(cs)
print("Updated DataSet_Fee_Summary_Reports.Designer.cs")
