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
        private readonly List<User> users;
        private IWebDriver driver;
        private string apiKey = "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";

        public MainForm()
        {
            InitializeComponent();
            users = new List<User>();
            this.Size = new Size(600, 400);
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                // 파일에서 사용자 정보 읽기
                string filePath = "users.dat";
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            User user = new User
                            {
                                ID = parts[0],
                                Password = parts[1]
                            };
                            users.Add(user);
                            cboxID1.Items.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 정보를 불러오는 도중 오류가 발생했습니다: {ex.Message}");
            }
        }

        private void SaveUsers()
        {
            try
            {
                // 사용자 정보를 파일에 저장
                string filePath = "users.dat";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (User user in users)
                    {
                        writer.WriteLine($"{user.ID},{user.Password}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 정보를 저장하는 도중 오류가 발생했습니다: {ex.Message}");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string newID = txtID1.Text;
            string newPassword = txtPW1.Text;

            // 사용자가 ID와 PW를 입력했는지 확인
            if (string.IsNullOrWhiteSpace(newID) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("ID와 비밀번호를 모두 입력하세요.");
                return;
            }

            // 이미 동일한 ID가 있는지 확인
            User existingUser = users.FirstOrDefault(user => user.ID == newID);

            if (existingUser != null)
            {
                // 이미 있는 사용자의 비밀번호를 업데이트
                existingUser.Password = newPassword;
                SaveUsers();
                MessageBox.Show("비밀번호가 업데이트되었습니다.");
            }
            else
            {
                // 새로운 사용자를 추가
                User user = new User
                {
                    ID = newID,
                    Password = newPassword
                };
                users.Add(user);
                cboxID1.Items.Add(user);

                // 사용자 정보를 저장
                SaveUsers();

                MessageBox.Show("새로운 사용자가 추가되었습니다.");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (cboxID1.SelectedItem != null)
            {
                User selectedUser = (User)cboxID1.SelectedItem;

                // 해당 사용자를 리스트에서 삭제
                users.Remove(selectedUser);

                // 콤보박스에서도 해당 사용자를 삭제
                cboxID1.Items.Remove(selectedUser);

                // 텍스트 상자 초기화
                txtID1.Clear();
                txtPW1.Clear();

                // 사용자가 삭제되었습니다. 메시지 표시
                MessageBox.Show("사용자가 삭제되었습니다.");

                // 사용자 정보를 파일에서 저장
                SaveUsers();
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
                    this.TopMost = true;
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
            ExploreInstagram();
        }

        string[] xpaths = {
            "//*[@id=\'mount_0_0_i9\']/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[2]/span/div/a/div",
            "//*[@id=\'mount_0_0_i9\']/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[2]/span/div/a/div/div[1]/div/div/svg",
            "//*[@id=\'mount_0_0_i9\']/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[2]/span/div/a/div/div[1]/div/div/svg/path",
            "//*[@id=\'mount_0_0_i9\']/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div"
        };

        private void FindXpath()
        {

            // 현재 페이지의 모든 iframe 요소를 찾음
            ReadOnlyCollection<IWebElement> iframes = driver.FindElements(By.TagName("iframe"));

            // 각 iframe에 대해 처리
            foreach (IWebElement iframe in iframes)
            {
                try
                {
                    // iframe으로 전환
                    driver.SwitchTo().Frame(iframe);

                    // 각 xpath에 대해 처리
                    foreach (string xpath in xpaths)
                    {
                        try
                        {
                            // 현재 iframe 내에서 엘리먼트를 찾음
                            IWebElement element = driver.FindElement(By.XPath(xpath));

                            // 요소가 존재하는지 확인
                            if (element != null)
                            {
                                // 클릭 가능 여부 확인
                                try
                                {
                                    element.Click();
                                    MessageBox.Show($"Iframe: {iframe.GetAttribute("id")} | {xpath} : Clickable");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show($"Iframe: {iframe.GetAttribute("id")} | {xpath} : Not Clickable");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Iframe: {iframe.GetAttribute("id")} | {xpath} : Element not found");
                            }
                        }
                        catch (StaleElementReferenceException)
                        {
                            MessageBox.Show($"Iframe: {iframe.GetAttribute("id")} | {xpath} : Stale element reference");
                        }
                    }
                }
                finally
                {
                    // 다시 기본 컨텍스트로 전환
                    driver.SwitchTo().DefaultContent();
                }
            }
        }

        private void ExploreInstagram()
        {
            try
            {
                ClickExp();
            }
            catch (NoSuchElementException ex)
            {
                MessageBox.Show($"Instagram 탐색에 실패했습니다. 원인: {ex.Message}");
            }
        }

        private void ClickExp()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

                // 좀 더 간결하고 의미 있는 XPath 사용
                string ExpXPath = "//*[@id='mount_0_0_qL']/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[3]/span/div/a";

                // ElementIsVisible 대신 ElementToBeClickable을 사용 -> 예외처리해야함
                IWebElement DivExp = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(ExpXPath)));
                
                DivExp.Click();
                Console.WriteLine("EXP 클릭 성공");
            }
            catch (NoSuchElementException)
            {
                // 예외를 던지지 않고 콘솔에 출력
                Console.WriteLine("탐색(Explore)을 찾을 수 없습니다.");
            }
        }

        private bool IsUrlChanged(string newUrl)
        {
            // 현재 URL과 비교하여 변경되었는지 확인
            return !driver.Url.Equals(newUrl);
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
