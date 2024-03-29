empl = dict()
names = dict()
nums = dict()
with open('Input.txt', 'r') as Inp:
    for count, line in enumerate(iter(Inp.readline, 'END\n')):
        if count % 2 == 0:
            boss = line.strip()
            if len(boss) != 4:
                boss, bossname = boss.split(' ', 1)
                names[boss] = bossname
                nums[bossname] = boss
            if not(boss in names.keys()):
                names[boss] = 'Unknown Name'
        else:
            sub = line.strip()
            if len(sub) != 4:
                sub, subname = sub.split(' ', 1)
                names[sub] = subname
            if not(sub in names.keys()):
                names[sub] = 'Unknown Name'

            if boss in empl.keys():
                empl[boss].append(sub)
            else:
                empl[boss] = [sub]
    BOSS = [Inp.readline()]
if not(BOSS[0].isdigit()):
    BOSS = [nums[BOSS[0]]]

ans = []
while BOSS:
    res = []
    [ans.extend(empl[t]) and res.extend(empl[t]) for t in BOSS if (t in empl.keys())]
    BOSS = res
ans = sorted([f'{n} {names[n]}' for n in ans])
if not ans:
    ans = ['NO']
with open('Output.txt', 'w') as Outp:
    Outp.write('\n'.join(ans))
