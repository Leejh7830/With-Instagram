using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace With_Instagram
{
    public partial class MainForm : Form
    {
        // private string apiKey = "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";
        private IWebDriver driver;
        private readonly UIManager uiManager;
        SpecificPostForm specificPostForm = new SpecificPostForm(); // https://www.instagram.com/p/C54n1MPPaJN/

        public MainForm()
        {
            InitializeComponent();
            uiManager = new UIManager();
            this.Size = new Size(600, 400);
            SetupDataGridView();
            uiManager.LoadUsers(cboxID1);
            uiManager.UpdateDGV(dgvUser);
        }

        private void SetupDataGridView()
        {
            // DataGridView에 컬럼 추가
            dgvUser.Columns.Add("NoColumn", "No");
            dgvUser.Columns.Add("IDColumn", "User ID");

            // DataGridView에 사용자 ID 컬럼 폭 설정
            int totalWidth = dgvUser.Width;
            int noColumnWidth = totalWidth / 5;
            int idColumnWidth = totalWidth * 4 / 5;

            dgvUser.Columns["NoColumn"].Width = noColumnWidth;
            dgvUser.Columns["IDColumn"].Width = idColumnWidth;

            // DataGridView에 사용자 ID 컬럼을 읽기 전용으로 설정
            dgvUser.Columns["IDColumn"].ReadOnly = true;
            // 행 헤더 열 숨기기
            dgvUser.RowHeadersVisible = false;
        }




        public void BtnSave_Click(object sender, EventArgs e)
        {
            string newID = txtID1.Text;
            string newPW = txtPW1.Text;

            // UI 매니저 클래스의 새로운 메서드 호출하여 사용자 정보 처리
            if (uiManager.IsInputValid(newID, newPW))
            {
                uiManager.SaveUser(newID, newPW, cboxID1);
                uiManager.UpdateDGV(dgvUser);
            }
        }
        
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (cboxID1.SelectedItem != null)
            {
                User selectedUser = (User)cboxID1.SelectedItem;
                uiManager.DeleteUser(selectedUser, cboxID1, txtID1, txtPW1);
                uiManager.UpdateDGV(dgvUser);
            }
            else
            {
                MessageBox.Show("삭제할 사용자를 선택하세요.");
            }
        }
        
        private void CboxID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxID1.SelectedItem != null)
            {
                User selectedUser = (User)cboxID1.SelectedItem;
                txtID1.Text = selectedUser.ID;
                txtPW1.Text = selectedUser.Password;
            }
        }

        /// /////////////////////////////////////////////////미완성
        private void DgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvUser.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvUser.Rows[e.RowIndex];
                if (selectedRow.DataBoundItem != null && selectedRow.DataBoundItem is User)
                {
                    User selectedUser = (User)selectedRow.DataBoundItem;
                    txtID1.Text = selectedUser.ID;
                    txtPW1.Text = selectedUser.Password;
                }
            }
        }




        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID1.Text))
            {
                MessageBox.Show("ID입력하세요");
                return;
            };

            // 실행 파일이 위치한 디렉토리를 기준으로 chromedriver.exe 경로 설정
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string chromeDriverRelativePath = $"chromedriver.exe";
            string chromeDriverPath = Path.GetFullPath(Path.Combine(executableLocation, chromeDriverRelativePath));

            // 크롬 드라이버 옵션 설정;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized"); // 창을 최대화하여 열기

            // 크롬 드라이버 실행
            driver = new ChromeDriver(chromeDriverPath, options);

            try
            {
                // 페이지 이동
                driver.Navigate().GoToUrl("https://www.instagram.com/");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                
                // XPath
                string idInputXPath = "//*[@id='loginForm']/div/div[1]/div/label/input";
                string pwInputXPath = "//*[@id='loginForm']/div/div[2]/div/label/input";
                string loginBtnXPath = "//*[@id='loginForm']/div/div[3]/button/div";

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(idInputXPath)));

                // ID 입력란에 값을 입력
                IWebElement idInput = driver.FindElement(By.XPath(idInputXPath));
                idInput.SendKeys(txtID1.Text);
                IWebElement pwInput = driver.FindElement(By.XPath(pwInputXPath));
                pwInput.SendKeys(txtPW1.Text);
                IWebElement loginBtn = driver.FindElement(By.XPath(loginBtnXPath));
                loginBtn.Click();

                Thread.Sleep(2000);

                if (uiManager.IsUrlChanged(driver, "https://www.instagram.com/accounts/onetap/?next=%2F"))
                {
                    this.Activate();
                    uiManager.SwapControlLocations(ViewExplore, ViewLogin); // 로그인성공 시 화면 전환
                }
            }
            catch (Exception ex)
            {
                // 더 자세한 에러 처리 및 로깅
                Console.WriteLine($"에러 발생: {ex.Message}\n스택 트레이스: {ex.StackTrace}");
            }
        }

        

        private void btnLike_Click(object sender, EventArgs e)
        {
            
            uiManager.Explore_Like(driver, txtCount);
        }

        private async void btnFollow_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("탐색창에서 게시물을 돌며 팔로우합니다.", "Follow", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // uiManager.Explore_Follow(driver, txtCount);
                await Task.Run(() => uiManager.Explore_Follow(driver, txtCount));
            }
        }




        private void btnLogout_Click(object sender, EventArgs e)
        {
            uiManager.SwapControlLocations(ViewLogin, ViewExplore);
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 폼이 닫힐 때 WebDriver 종료
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        private void btnSpecificPost_Click(object sender, EventArgs e)
        {
            SpecificPostForm specificPostForm = new SpecificPostForm();
            specificPostForm.TopMost = true; // 최상위로 설정
            specificPostForm.FormClosed += SpecificPostForm_FormClosed; // 폼이 닫히면 이벤트 처리
            specificPostForm.Show();
        }

        private void SpecificPostForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SpecificPostForm specificPostForm = sender as SpecificPostForm;
            if (specificPostForm != null)
            {
                specificPostForm.TopMost = false; // 최상위 설정 해제
            }
        }


    }
}



/*   
        private void InitializeDriver()
        {
            string driverPath = DownloadLatestChromeDriver();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            // WebDriver 초기화
            IWebDriver driver = new ChromeDriver(driverPath, options);

            // 나머지 코드에서 이 driver를 사용할 수 있음
        }

        private string DownloadLatestChromeDriver()
        {
            // 최신 버전의 ChromeDriver를 다운로드할 URL
            string downloadUrl = "https://chromedriver.storage.googleapis.com/LATEST_RELEASE";

            // 최신 버전 가져오기
            WebClient client = new WebClient();
            string latestVersion = client.DownloadString(downloadUrl).Trim();

            // 최신 버전에 해당하는 ChromeDriver 다운로드 경로 생성
            string downloadPath = $"https://chromedriver.storage.googleapis.com/{latestVersion}/chromedriver_win32.zip";

            // WebDriver 다운로드
            string driverDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver");
            string zipFilePath = Path.Combine(driverDirectory, "chromedriver.zip");

            // TODO: 여기에 파일 다운로드 및 압축 해제 코드 추가

            return driverDirectory;
        }

        */