public class NQueens {
    public IList<IList<string>> SolveNQueens(int n) {
        char[,] board; 
        var placements = new List<Positions>();
        var res = new List<List<Positions>>();
        place(n, 0,0,0,placements, res);
        IList<IList<string>> placements2 = new List<IList<string>>();
        for(int i = 0; i < res.Count;i++){
            board = new char[n, n];
            initializeBoard(board, res[i]);
            storeResult(board, placements2);
        }
        return placements2;
    }
    private void storeResult(char[,] board, IList<IList<string>> result)
            {
                List<string> temp = new List<string>();
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    string rowStr = string.Join(string.Empty, GetRow(board, i));
                    temp.Add(rowStr);
                }
                result.Add(temp);
            }
            public char[] GetRow(char[,] matrix, int rowNumber)
            {
                return Enumerable.Range(0, matrix.GetLength(1))
                        .Select(x => matrix[rowNumber, x])
                        .ToArray();
            }
 void initializeBoard(char[,] board, List<Positions> positions)
            {
                HashSet<Positions> set = new HashSet<Positions>(positions);
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(0); j++)
                    {
                        if(set.Contains(new Positions(i,j))){
                            board[i,j] = 'Q';
                        }
                        else{
                            board[i, j] = '.';
                        }
                        
                    }
                }
            }
    void place(int n, int q, int r, int c, List<Positions> placements, List<List<Positions>> res) {
        if(q==n) {
            res.Add(new List<Positions>(placements));
            return;
        }
        for(int col = c; col < n && r < n; col++) {
            if(canPlaceQueen(r, col, n, placements)){
                //System.Console.WriteLine($"{r}:{col}");
                placements.Add(new Positions(r, col));
                place(n, q+1, r+1, 0, placements, res);
                placements.RemoveAt(placements.Count-1);
            }
        }

    }
    bool canPlaceQueen(int r, int c,int n, IList<Positions> placements){
        return !(isAttackVerticalUp(r, c, placements) || isAttackVerticalLeft(r, c, placements)
        || isAttackLeftUp(r, c, placements) || isAttackRightUp(r, c,n, placements));
    }

     bool isAttackLeftUp(int r, int c, IList<Positions> placements){
        HashSet<Positions> set = new HashSet<Positions>(placements);
        c--;
        for(int i=r-1;i>=0;i--){
            if(i<0 || c<0) break;
            if(set.Contains(new Positions(i,c)))
                return true;
            c--;
        }
        
        return false;
    }

    bool isAttackRightUp(int r, int c, int n, IList<Positions> placements){
        HashSet<Positions> set = new HashSet<Positions>(placements);
        c++;
        for(int i=r-1;i>=0;i--){
            if(i<0 || c>=n) break;
            if(set.Contains(new Positions(i,c)))
                return true;
            c++;
        }
        
        return false;
    }
    bool isAttackVerticalUp(int r, int c, IList<Positions> placements){
        for(int i=0;i<placements.Count;i++){
            if(placements[i].col==c)
                return true;
        }
        return false;
    }

    bool isAttackVerticalLeft(int r, int c, IList<Positions> placements){
        for(int i=0;i<placements.Count;i++){
            if(placements[i].row==r)
                return true;
        }
        return false;
    }
    public class Positions{
        public int row;
        public int col;
        public Positions(int r, int c)
        {
            row = r;
            col = c;
        }
        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            // TODO: write your implementation of Equals() here
            Positions o = (Positions)obj;
            return this.row==o.row && this.col==o.col;
            //return base.Equals (obj);
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            //throw new System.NotImplementedException();
            return this.row.GetHashCode()*this.col.GetHashCode();
        }
    }
}