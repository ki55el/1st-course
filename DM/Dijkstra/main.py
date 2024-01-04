with open('Input.txt', 'r') as Inp:
    G = [list(map(float, line.split())) for line in Inp.read().split('\n')]
    n = len(G)
    dist = [float('inf')] * n
    visit = []
    start = 0   # int(input())

dist[start] = 0
for _ in range(n):
    s, w = min([(dist[v], v) for v in range(n) if v not in visit])
    visit.append(w)
    for v in range(n):
        dist[v] = min(dist[v], dist[w]+G[w][v])

[print(f'{start}→{v}: {d}') for v, d in enumerate(dist)]
