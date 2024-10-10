namespace Naja_Negra
{ 
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Game : Form
    {
        private const int GAME_SQUARE = 35;
        private const int GAME_WIDTH = 17;
        private const int GAME_HEIGHT = 15;
        private readonly Random random = new Random();

        private uint score = 0;
        private Direction direction = Direction.right;
        private List<Point> snake = new List<Point>();
        private Point food = Point.Empty;

        private enum Direction
        {
            right,
            left,
            up,
            down
        }

        public Game()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            score = 0;
            direction = Direction.right;
            snake.Clear();
            snake.Add(new Point(5, 6));
            snake.Add(new Point(4, 6));
            snake.Add(new Point(3, 6));
            food = new Point(12, 8);

            timer.Interval = 100;
            timer.Start();
        }

        private void MoveSnake()
        {
            Point head = snake.First();
            Point newHead = head;

            switch (direction)
            {
                case Direction.right:
                    newHead.X++;
                    break;
                case Direction.left:
                    newHead.X--;
                    break;
                case Direction.up:
                    newHead.Y--;
                    break;
                case Direction.down:
                    newHead.Y++;
                    break;
            }

            snake.Insert(0, newHead);

            if (newHead == food)
            {
                score++;
                timer.Interval--;
                PlaceFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        private void PlaceFood()
        {
            Point proposal = new Point(random.Next(0, GAME_WIDTH), random.Next(0, GAME_HEIGHT));
            while (snake.Contains(proposal))
            {
                proposal = new Point(random.Next(0, GAME_WIDTH), random.Next(0, GAME_HEIGHT));
            }
            food = proposal;
        }

        private void CheckCollision()
        {
            Point head = snake.First();

            if (head.X < 0 || head.X >= GAME_WIDTH ||
                head.Y < 0 || head.Y >= GAME_HEIGHT)
            {
                GameOver();
            }

            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[i] == head)
                {
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            timer.Stop();
            MessageBox.Show($"Game Over!", "Naja Negra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StartGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            main.Invalidate();
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (timer.Enabled)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (direction != Direction.down)
                        {
                            direction = Direction.up;
                        }
                        break;
                    case Keys.Down:
                        if (direction != Direction.up)
                        {
                            direction = Direction.down;
                        }
                        break;
                    case Keys.Left:
                        if (direction != Direction.right)
                        {
                            direction = Direction.left;
                        }
                        break;
                    case Keys.Right:
                        if (direction != Direction.left)
                        {
                            direction = Direction.right;
                        }
                        break;
                }
            }
        }

        private void Background_Paint(object sender, PaintEventArgs e)
        {
            if (timer.Enabled)
            {
                Graphics g = e.Graphics;

                g.DrawImage(Properties.Resources.apple, new Rectangle(food.X * GAME_SQUARE, food.Y * GAME_SQUARE, GAME_SQUARE, GAME_SQUARE));

                switch (direction)
                {
                    case Direction.right:
                        g.DrawImage(RotateImage(Properties.Resources.head, 0), new Rectangle(snake[0].X * GAME_SQUARE, snake[0].Y * GAME_SQUARE, GAME_SQUARE, GAME_SQUARE));
                        break;
                    case Direction.left:
                        g.DrawImage(RotateImage(Properties.Resources.head, 180), new Rectangle(snake[0].X * GAME_SQUARE, snake[0].Y * GAME_SQUARE, GAME_SQUARE, GAME_SQUARE));
                        break;
                    case Direction.up:
                        g.DrawImage(RotateImage(Properties.Resources.head, 270), new Rectangle(snake[0].X * GAME_SQUARE, snake[0].Y * GAME_SQUARE, GAME_SQUARE, GAME_SQUARE));
                        break;
                    case Direction.down:
                        g.DrawImage(RotateImage(Properties.Resources.head, 90), new Rectangle(snake[0].X * GAME_SQUARE, snake[0].Y * GAME_SQUARE, GAME_SQUARE, GAME_SQUARE));
                        break;
                }

                for (int i = 1; i < snake.Count - 1; i++)
                {
                    g.DrawImage(Properties.Resources.body, new Rectangle(snake[i].X * GAME_SQUARE, snake[i].Y * GAME_SQUARE, GAME_SQUARE, GAME_SQUARE));
                }

                g.DrawImage(Properties.Resources.tail, new Rectangle(snake[snake.Count - 1].X * GAME_SQUARE, snake[snake.Count - 1].Y * GAME_SQUARE, GAME_SQUARE, GAME_SQUARE));

                scoreText.Text = score.ToString();
            }
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap rotatedBmp = new Bitmap(img.Width, img.Height);
            rotatedBmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                g.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
                g.RotateTransform(rotationAngle);
                g.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
                g.DrawImage(img, new Point(0, 0));
            }

            return rotatedBmp;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            License license = new License();
            if (license.IsActive())
            {
                StartGame();
                return;
            }

            Activation activation = new Activation(license);
            if (activation.ShowDialog() == DialogResult.OK)
            {
                StartGame();
            }
            else
            {
                Close();
            }
        }
    }
}
