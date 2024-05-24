import { useEffect, useState } from 'react';
import './App.css';

interface LeaderboardItem {
  id: string;
  name: string;
  score: number;
}

function App() {
  const [items, setItems] = useState<LeaderboardItem[]>([]);
  const [name, setName] = useState<string>('');
  const [score, setScore] = useState<string>('');
  useEffect(() => {
    populateLeaderboard();
  }, []);

  const selected = new Set<string>();
  const shownItems = [...items].sort((a, b) => a.score > b.score ? -1 : 1).filter((item) => {
    const included = !selected.has(item.name);
    selected.add(item.name);
    return included;
  });
  if (shownItems.length > 3) {
    shownItems.splice(3, shownItems.length - 3);
  }
  return (
    <div>
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Score</th>
          </tr>
        </thead>
        <tbody>
          {shownItems.map(item =>
            <tr key={item.id}>
              <td>{item.name}</td>
              <td>{item.score}</td>
            </tr>
          )}
        </tbody>
      </table>
      <div>
        Name: <input type="text" onChange={textChange} value={name} />
      </div>
      <div>
        Score: <input type="text" onChange={scoreChange} value={score} />
      </div>
      <div>
        <button onClick={addScore}>Add</button>
      </div>
    </div>
  );

  function addScore() {
    fetch('leaderboard', {
      method: 'POST',
      body: JSON.stringify({ name, score: Number(score) }),
      headers: { 'content-type': 'application/json' },
    });
    setItems([...items, { id: items.length.toString(), name, score: Number(score) }]);
  }

  function textChange(event: React.FormEvent<HTMLInputElement>) {
    setName(event.currentTarget.value);
  }

  function scoreChange(event: React.FormEvent<HTMLInputElement>) {
    setScore(event.currentTarget.value);
  }

  async function populateLeaderboard() {
    const response = await fetch('leaderboard');
    const data = await response.json();
    setItems(data);
  }
}

export default App;