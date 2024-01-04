with open('Input.txt', 'r') as Inp:
    G = [list(map(float, line.split())) for line in Inp.read().split('\n')]
    n = len(G)
    V = [{v} for v in range(n)]

E = []
for j in range(n):
    for i in range(j):
        if G[i][j] != float('inf'):
            E.append((G[i][j], i, j))

mst = []
for e, v, u in sorted(E):
    if len(mst) == n-1:
        break
    if V[v] != V[u]:
        mst.append((e, v, u))
        vu = V[v] | V[u]
        for i in vu:
            V[i] = vu

print(sum([e for e, v, u in mst]))
