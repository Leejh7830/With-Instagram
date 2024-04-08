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
        // private readonly List<User> users;

        public MainForm()
        {
            InitializeComponent();
            uiManager = new UIManager();
            // users = new List<User>();
            this.Size = new Size(600, 400);
            uiManager.LoadUsers(cboxID1);
        }

        public void BtnSave_Click(object sender, EventArgs e)
        {
            string newID = txtID1.Text;
            string newPW = txtPW1.Text;

            // UI 매니저 클래스의 새로운 메서드 호출하여 사용자 정보 처리
            if (uiManager.IsInputValid(newID, newPW))
            {
                uiManager.AddOrUpdateUser(newID, newPW, cboxID1);
            }
        }
        
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (cboxID1.SelectedItem != null)
            {
                User selectedUser = (User)cboxID1.SelectedItem;
                // string ID = (string)cboxID1.SelectedItem;

                uiManager.DeleteUser(selectedUser, cboxID1, txtID1, txtPW1);
            }
            else
            {
                MessageBox.Show("삭제할 사용자를 선택하세요.");
            }
        }
        
        private void cboxID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxID1.SelectedItem != null)
            {
                User selectedUser = (User)cboxID1.SelectedItem;
                txtID1.Text = selectedUser.ID;
                txtPW1.Text = selectedUser.Password;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
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

            // 크롬 드라이버 옵션 설정
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

                if (IsUrlChanged("https://www.instagram.com/accounts/onetap/?next=%2F"))
                {
                    this.Activate();
                    SwapControlLocations(ViewExplore, ViewLogin); // 로그인성공 시 화면 전환
                }
            }
            catch (Exception ex)
            {
                // 더 자세한 에러 처리 및 로깅
                Console.WriteLine($"에러 발생: {ex.Message}\n스택 트레이스: {ex.StackTrace}");
            }
        }

        // 두 컨트롤의 위치를 교환하는 함수
        private void SwapControlLocations(Control control1, Control control2)
        {
            Point tempLocation = control1.Location;
            control1.Location = control2.Location;
            control2.Location = tempLocation;
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            // 탐색버튼의 XPath를 먼저 찾고 탐색해야함
            uiManager.ExploreInstagram(driver);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private bool IsUrlChanged(string newUrl)
        {
            // 현재 URL과 비교하여 변경되었는지 확인
            return !driver.Url.Equals(newUrl);
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